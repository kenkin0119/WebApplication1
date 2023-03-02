;
$(function () {

    DateDropDownList();
});

function DateDropDownList() {
    var $DateDropdownlist = $('input.Date-DropDownList');
    $DateDropdownlist.dateDropDowns({
        dateFormat: 'yy-MM-DD',
        monthNames: ['01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12'],
        yearStart: '1914', yearEnd: '2014',
        yearOption: '年', monthOption: '月', dayOption: '日'
    });
}