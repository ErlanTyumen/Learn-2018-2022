function updatePopovers() {
  let popoverTriggerList = [].slice.call(document.querySelectorAll('[data-toggle="popover"]'))
  let popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
    return new bootstrap.Popover(popoverTriggerEl)
  })
}
function clearHighlights() {
  $("p").html(function(index, text) {
    return text.replace(/<span class="find-item" tabindex="0" data-toggle="popover" data-trigger="hover focus" data-content="Найденное вхождение" data-original-title="">(.*?)<\/span>/g, "$1");
  });
}
$(document).ready(function(){
  $('#mySearch').submit(function () {
    clearHighlights();
    let val = $('#myInput').val();
    let counter = 0;
    $("p").html(function(index, text) {
      return text.replace(new RegExp(val,'g'), function () {counter++; return "<span class=\"find-item\" tabindex=\"0\" data-toggle=\"popover\" data-trigger=\"hover focus\" data-content=\"Найденное вхождение\" data-original-title=\"\">" + val + "</span>";});
    });
    $('#myModal').modal('show');
    $(".modal-body").html("Найдено вхождений: " + counter);
    updatePopovers();
    return false;
  })
  $('input[type=search]').bind('input', function () {
    if ($(this).val() == "") {
      clearHighlights();
      updatePopovers();
    }
  });
});