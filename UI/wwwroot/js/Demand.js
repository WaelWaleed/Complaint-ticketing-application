$('#AddDemand').on('click', function () {
    var demand = $('#DemandInput').val();

    if (demand != null && demand !== "" && demand !== "undefined") {
        var RowCount = $('#DemandTBody tr').length;
        var row = `<tr class="Row_` + RowCount +`">
                    <input type="hidden" value="`+ demand + `" name="Complaint.Demands[` + RowCount +`].Description" />
                    <td>`+ RowCount +`</td>
                    <td>`+demand+`</td>
                    <td>
                        <span id="" class="EditDemand"><i class="fas fa-edit text-warning"></i></span>
                        <span id="" class="DeleteDemand"><i class="fas fa-trash text-danger"></i> </span>
                    </td>
                </tr>`
        $('#DemandTBody').append(row);
        $('#DemandInput').val('');
        Edit_AddEventListener();
        Delete_AddEventListener();
    }
});

function Edit_AddEventListener() {
    var AllEditButton = $('.EditDemand');
    //console.log(AllEditButton);
    for (var i = 0; i < AllEditButton.length; i++) {
        
        AllEditButton[i].addEventListener('click', function () {
            $('.EditDemand').one('click', function (e) {
                //debugger;
                e.stopImmediatePropagation();
                var classname = $(this).parent().parent().attr("class");
                EditDemand(classname);
            });
        });
    }
}

function Delete_AddEventListener() {
    var AllEditButton = $('.DeleteDemand');
    //console.log(AllEditButton);
    for (var i = 0; i < AllEditButton.length; i++) {

        AllEditButton[i].addEventListener('click', function () {
            $('.DeleteDemand').one('click', function (e) {
                //debugger;
                e.stopImmediatePropagation();
                var classname = $(this).parent().parent().attr("class");
                DeleteDemand(classname);
            });
        });
    }
}

function EditDemand(classname) {
    //debugger;
    //alert("Edit" + classname);
    var Row = $('#DemandTBody .' + classname);
    console.log(Row);
    var input = $(Row).find('input').val();
    $('#DemandInput').val(input);
    //debugger;
    $('#DemandTBody tr').remove('.' + classname);
    RenumberingRows();
}

function DeleteDemand(classname) {
    var Row = $('#DemandTBody .' + classname);
    $('#DemandTBody tr').remove('.' + classname);
    RenumberingRows();
}

function RenumberingRows() {
    var TableBody = document.getElementsByTagName('tr');
    Array.from(TableBody).forEach(function (value, index) {
        if (index > 0) {
            //debugger;
            index--;
            value.className = "Row_" + index;
            value.querySelector('td').innerText = index ;
            $(value.getElementsByTagName('input')).attr('name', 'Complaint.Demands[' + index + '].Description');
        }
    });
    
}

//$('.EditDemand').on('click', function () {
//    alert("edit demand");
//})