using Castle.Core.Resource;
using DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UI.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UI.Controllers
{
    public class ComplaintController : Controller
    {
        private readonly IClientContainer _client;
        public ComplaintController(IClientContainer Client)
        {
            _client = Client;
        }
        public async Task<IActionResult> Index()
        {
            //var x = User.FindFirst("Id");

            //var token = await HttpContext.GetTokenAsync("access_token");

            var AllComplaints = await _client.Complaint.GetAll();
            return View(AllComplaints);
        }
        public async Task<IActionResult> AddEdit(int ID)
        {
            if(ID == 0)
            {
                return View(new DTO.Complaint() { Demands = new List<DTO.Demand>() });
            }
            else
            {
                var Complaint = await _client.Complaint.GetByID(ID);
                return View(Complaint);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromForm] DTO.Complaint Complaint)
        {

            Complaint.Demands = Complaint.Demands != null ? Complaint.Demands : new List<Demand>();
            Complaint.UserID = 1;


            #region FileHandler
            var file = Request.Form.Files["Attachment"];
            Complaint.AttachmentInfo = new List<DTO.FileInfo>();


            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                MemoryStream ms = new MemoryStream();
                Request.Form.Files[i].CopyTo(ms);

                Complaint.AttachmentInfo.Add(new DTO.FileInfo
                {
                    FileName = Request.Form.Files[i].FileName,
                    ContentType = Request.Form.Files[i].ContentType,
                    Bytes = ms.ToArray()
                });

                Complaint.Attachment += Request.Form.Files[i].FileName;
            }
            #endregion


            //Complaint.Demands = new List<Demand>() { new Demand() { Description = "test Demand" } };
            if (Complaint.ID != null)
            {
                if (Complaint.ID == 0)
                {
                    var Result = await _client.Complaint.Insert(Complaint);
                    if (Result.IsSuccess)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in Result.Result.Children())
                        {
                            var x = item as JProperty;
                            var name = x.Name;
                            var Values = x.Values();
                            foreach (var item1 in Values)
                            {
                                var JValue = item1 as JValue;
                                var errorValue = item1.ToString();
                                ModelState.AddModelError(name, errorValue);
                            }
                        }
                        return View("AddEdit", Complaint);
                    }
                }
                else
                {
                    if(Complaint.Attachment == null)
                    {
                        var ExistingAttachment = await _client.Complaint.GetByID(Complaint.ID);
                        Complaint.Attachment = ExistingAttachment.Attachment;
                    }
                    var Result = await _client.Complaint.Update(Complaint);
                    if (Result.IsSuccess)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in Result.Result.Children())
                        {
                            var x = item as JProperty;
                            var name = x.Name;
                            var Values = x.Values();
                            foreach (var item1 in Values)
                            {
                                var JValue = item1 as JValue;
                                var errorValue = item1.ToString();
                                ModelState.AddModelError(name, errorValue);
                            }
                        }
                        return View("AddEdit", Complaint);
                    }
                }

            }

            return null;

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.Complaint Complaint = new Complaint
            {
                ID = ID,
                IsDeleted = true
            };
            var Forcast = await _client.Complaint.Delete(Complaint);

            if (Forcast != null && Forcast.ID != -99)
            {
                return Json(Forcast);
            }
            else
            {
                var result = new
                {
                    result = Forcast,
                    type = Forcast.GetType().Name,
                    errorReasonMessage = "Cannot Delete"
                };
                return Json(result);
            }

        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int ID, bool status)
        {
            DTO.Complaint Complaint = await _client.Complaint.GetByID(ID);
            if (Complaint != null)
            {
                Complaint.Approved = status;
                Response Response = await _client.Complaint.Update(Complaint);
                return Json(Complaint.Approved);
            }
            else
            {
                return null;
            }
            
        }

        [HttpGet]
        public async Task<FileResult> DownloadFile(string fileName)
        {
            var FileInfo = await _client.Complaint.DownloadFile(fileName);
            return File(FileInfo.Bytes, FileInfo.ContentType, FileInfo.FileName);
        }


    }
}
