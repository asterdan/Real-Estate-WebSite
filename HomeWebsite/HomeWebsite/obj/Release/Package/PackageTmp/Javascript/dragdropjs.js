function createGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

var sections = [
{
    Id: 1, Name: 'Section-1', RowOrder: 1, Colspan: 1, Rowspan: 1, Color: 'panel-success', RowCount: 2,
    Fields: [
    { FieldId: 1, Name: 'name', RowOrder: 1, Colspan: 1, Rowspan: 1 },
    { FieldId: 2, Name: 'surname', RowOrder: 1, Colspan: 1, Rowspan: 1 },
    { FieldId: 3, Name: 'city', RowOrder: 2, Colspan: 2, Rowspan: 1 }]
},
{
    Id: 2, Name: 'Section-2', RowOrder: 1, Colspan: 1, Rowspan: 1, Color: 'panel-info', RowCount: 2,
    Fields: [
    { FieldId: 1, Name: 'name', RowOrder: 1, Colspan: 1, Rowspan: 1 },
    { FieldId: 1, Name: 'surname', RowOrder: 2, Colspan: 1, Rowspan: 1 }]
},
{
    Id: 3, Name: 'Section-3', RowOrder: 2, Colspan: 2, Rowspan: 1, Color: 'panel-danger', RowCount: 2,
    Fields: [
    { FieldId: 1, Name: 'name', RowOrder: 1, Colspan: 1, Rowspan: 1 },
    { FieldId: 2, Name: 'surname', RowOrder: 1, Colspan: 1, Rowspan: 1 },
    { FieldId: 3, Name: 'email', RowOrder: 1, Colspan: 1, Rowspan: 1 },
    { FieldId: 4, Name: 'city', RowOrder: 2, Colspan: 2, Rowspan: 1 },
    { FieldId: 5, Name: 'county', RowOrder: 2, Colspan: 1, Rowspan: 1 }]
}
];

var layout = { Id: 1, RowCount: 2, Sections: sections };
//layout = [];

$(function () {
    var table = $('<table class="table table-bordered table-layout" />');

    for (var i = 0; i < layout.RowCount; i++) {
        var tr = $('<tr/>');
        $.each(layout.Sections, function () {
            if (this.RowOrder == i + 1) {
                var panel = $('.panel.hidden').clone()
                    .removeClass('hidden')
                    .addClass(this.Color);

                panel.find('.panel-heading span [contenteditable]').attr('data-name', this.Name).html(this.Name);

                if (this.Fields.length > 0) {
                    for (var j = 0; j < this.RowCount; j++) {
                        var pTr = $('<tr/>');
                        $.each(this.Fields, function () {
                            if (this.RowOrder == j + 1) {

                                var item = $('<div/>', { id: this.FieldId, title: this.Name, 'class': 'col-lg-12', cf: '' })
                                                    .append($('<div/>', { 'class': 'draggable col-lg-12 bg-primary' })
                                                    .append($('<i/>', { 'class': 'fa fa-database' })).append(' ' + this.Name)),
                                td = $('<td/>', {
                                    colspan: this.Colspan,
                                    rowspan: this.Rowspan
                                }).append(item);

                                pTr.append(td);
                            }
                        });
                        var uniqId = createGuid();
                        panel.find('.panel-body').attr('id', uniqId); // benzersiz id
                        panel.find('.tools').attr('data-id', uniqId); // benzersiz id
                        panel.find('.panel-body table').append(pTr);
                    }
                }

                tr.append($('<td/>', {
                    colspan: this.Colspan,
                    rowspan: this.Rowspan
                }).append(panel));

            }
        });
        table.append(tr);
    }

    $("#PageLayout").append(table);
});

function draggableInit() {
    $('.panel-body td, .panel-body.source').sortable({
        handle: '.draggable',
        connectWith: '.panel-body td, .panel-body.source',
        receive: function (event, ui) {
            var dragItemId = ui.item.attr('id'),
                sourceZone = ui.sender, draggedItem = ui.item,
                sourceId = sourceZone.closest('.panel').attr('id'),
                targetId = draggedItem.closest('.panel').attr('id');

            draggedItem.removeClass().addClass('col-lg-12');

            sourceZone.removeClass('ui-selected').addClass('empty');
            if (targetId == 'cf_source') {
                draggedItem.removeClass().addClass('col-lg-3');
            } else {
                draggedItem.parent().removeClass();
                if (draggedItem.parent().children('div').length > 1) {
                    if (sourceId != 'cf_source') sourceZone.removeClass();
                    else draggedItem.removeClass().addClass('col-lg-3');
                    sourceZone.append(draggedItem)
                }
            }

            selectableInit();
            eventChangeData();
        },
        update: function (event, ui) {
            eventChangeData();
        }
    }).disableSelection();
}

//only empty cell selectable
function selectableInit() {
    $('table.table-layout, table.table-panel').selectable({
        filter: "td.empty",
        autoRefresh: true,
        selecting: function (event, ui) {
            var td = $(ui.selecting);
            //if (td.closest('table').hasClass('table-layout')) {
            //    console.log('table-layout');
            //} else {
            //    console.log('table-panel');
            //}
        },
        stop: function (event, ui) {
            $(event.target).find(':not(.empty)').removeClass('ui-selected');
            enableAddPanelButton($(event.target));
            selectableInit();
        }
    });
}

function enableAddPanelButton(table) {
    if (table.find('.ui-selected').length == 1) {
        $('.btn-add-panel').show();
    } else {
        $('.btn-add-panel').hide();
    }
}

// Panel color setting
$('body').on('click', '[data-color]', function () {
    var panel = $(this).closest('.panel');
    var color = $(this).data('color');
    panel.removeClass().addClass('panel').addClass('panel-' + color).attr('data-panelcolor', color);
    eventChangeData();
});

// Panel slide toggle effect
$('body').on('click', '.panel-toggle', function () {
    var panelBlock = $(this).closest('.panel').children('.panel-body');
    panelBlock.slideToggle();
});

//contenteditable
$('body').on('click', '.contenteditable', function () {
    var span = $(this).closest('span');
    var contentEditable = span.children('[contenteditable]');
    contentEditable.attr('contenteditable', true).focus();
    contentEditable.blur(function () {
        $(this).attr('contenteditable', false);
    });
});

$('body').on('keydown', '[contenteditable="true"]', function (e) {
    var item = $(this);

    if (e.keyCode === 27) {
        item.html(item.data('name'));
        item.blur();
        return false;
    } else {
        eventChangeData();
    }
    if (e.keyCode === 13) {
        item.blur();
        return false;
    }
});

function eventChangeData() {
    // data deðiþikliði oldu
}

function tableSizer() {
    var sizeChooser = $('.SizeChooser');
    sizeChooser.each(function () {
        var trs = $(this).find('table tr'),
            tds = $(this).find('table td'),
            buttons = $(this).find('table td button');

        trs.each(function (i) {
            var $tr = $(this);
            $tr.attr('data-index', i + 1);
            $tr.find('td').each(function (j) {
                $(this).attr('data-index', j + 1);
            });
        });

        tds.mouseover(function () {
            var trIndex = $(this).closest('tr').data('index'),
                tdIndex = $(this).data('index');

            var colXrow = $(this).closest('.SizeChooser').find('.colXrow');
            colXrow.eq(0).html(trIndex);
            colXrow.eq(1).html(tdIndex);

            buttons.removeClass('btn-info');
            buttons.each(function () {
                var $button = $(this);
                if ($button.closest('tr').data('index') < trIndex + 1 && $button.parent().data('index') < tdIndex + 1) {
                    $button.addClass('btn-info');
                }
            });
        });
    });
}

$(function () {
    //table  generator
    $('body').on('click', 'td[data-index] button', function () {
        var trIndex = $(this).closest('tr').data('index'), tdIndex = $(this).parent().data('index'),
            tableId = '#' + $(this).closest('.tools').data('id'),
            table = $(tableId + ' > table'), trs = $(tableId + ' > table > tbody > tr'),
            trOrder, tdMaxCount = 0, newTrCount = (trIndex - trs.length), newTdCount, isDeletable = null;

        trs.each(function () {
            var $tr = $(this), $tdLen = $tr.children('td').length;
            if ($tdLen > tdMaxCount) tdMaxCount = $tdLen;
        });

        newTdCount = (tdIndex - tdMaxCount);
        trs.each(function () {
            var $tr = $(this);
            for (var j = 0; j < newTdCount; j++) $tr.append($('<td/>', { colspan: 1, rowspan: 1, 'class': 'empty' }));

            //seçim dýþý kalan td siler
            if (newTdCount < 0) for (i = 0; i < Math.abs(newTdCount) ; i++) {
                var last = $tr.find('td').last();
                last.find('div[cf]').clone().removeClass().addClass('col-lg-3').appendTo('#cf_source .panel-body');
                last.remove();
            }

        });
        tdMaxCount += newTdCount;

        // yeni tr ler ekler
        for (trOrder = 0; trOrder < newTrCount ; trOrder++) {
            var tr = $('<tr/>');
            for (var i = 0; i < tdMaxCount; i++) tr.append($('<td/>', { colspan: 1, rowspan: 1, 'class': 'empty' }));
            table.append(tr);
        }

        //seçim dýþý kalan tr siler
        if (newTrCount < 0) for (trOrder = 0; trOrder < Math.abs(newTrCount) ; trOrder++) {
            var last = $(tableId + ' > table > tbody > tr').last();
            last.find('div[cf]').clone().removeClass().addClass('col-lg-3').appendTo('#cf_source .panel-body');
            last.remove();
        }

        draggableInit();
        eventChangeData();
    });

    // seçili hüçrelerin merge edilmesi
    $('body').on('click', '.tools .merge', function () {
        var containerId = '#' + $(this).closest('.tools').data('id'),
            table = $(containerId + ' > table > tbody'),
            selectedSelector = containerId + ' > table > tbody > tr .ui-selected',
            cs = 0, rs = 1;

        table.find('tr').each(function () {
            var $tr = $(this),
                selecteds = $tr.find('.ui-selected');

            cs = 0;
            selecteds.each(function () {
                cs += parseInt($(this).attr('colspan'));
                var newRs = parseInt($(this).attr('rowspan'));
                if (newRs > rs) rs = newRs;
            });
            selecteds.last().after(($('<td/>', { colspan: cs, rowspan: rs, 'class': 'empty ui-selected' })));
            selecteds.remove();
        });

        rs = 0, cs = 1;
        $(selectedSelector).each(function () {
            rs += parseInt($(this).attr('rowspan'));
            var newCs = parseInt($(this).attr('colspan'));
            if (newCs > cs) cs = newCs;
        });
        $(selectedSelector).each(function (i) {

            var $elem = $(this);
            if (i == 0) {
                $elem.attr('rowspan', rs).attr('colspan', cs);
            } else {
                $elem.remove();
            }
        });


        draggableInit();
        eventChangeData();
        enableAddPanelButton(table);
    });
});

$(function () {
    draggableInit();
    selectableInit();
    tableSizer();

    $('.btn-add-panel').click(function () {
        var selected = $('#PageLayout .ui-selected');
        if (selected.length == 1) {
            var cloned = $('.panel.hidden').clone();

            var uniq = createGuid();
            cloned.find('.panel-body').attr('id', uniq); // benzersiz id
            cloned.find('.tools').attr('data-id', uniq); // benzersiz id

            selected.append(cloned.removeClass('hidden')).removeClass();

            selectableInit();
            tableSizer();
        }
    });
});
