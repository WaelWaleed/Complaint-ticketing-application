$('.Approve').on('click', function () {
    //debugger;
    var id = parseInt($(this).attr('data-value'));
    var element = $(this);
    $.ajax({
        url: '/Complaint/ChangeStatus',
        method: 'POST',
        data: {
            ID: id,
            status: true
        },
        success: function (result) {
            //debugger;
            if (result) {
                //debugger;
                //console.log($(this).parent().siblings('.status'));
                //console.log($(this));
                $(element).parent().siblings('.status').attr('style', 'background-color:#90EE90');
                $(element).parent().siblings('.status').text("Approved");
            }
            //alert(result);
        }
    });
    //alert("Accepted");
});
$('.Reject').on('click', function () {
    //debugger;
    var id = parseInt($(this).attr('data-value'));
    var element = $(this);
    $.ajax({
        url: '/Complaint/ChangeStatus',
        method: 'POST',
        data: {
            ID: id,
            status: false
        },
        success: function (result) {
            //debugger;
            if (!result) {
                //debugger;
                //console.log($(this).parent().siblings('.status'));
                //console.log($(element));
                $(element).parent().siblings('.status').attr('style', 'background-color:#FD1C03');
                $(element).parent().siblings('.status').text("Rejected");
                //console.log($(element).parent().siblings('.status'));
            }
            //alert(result);
        }
    });
    //alert("Accepted");
});