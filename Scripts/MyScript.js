var links = document.querySelectorAll('.feedback a');
links.forEach(function (item, i, arr) {
    item.addEventListener('click', GoToFeedbackForm);
});

function GoToFeedbackForm(event) {
    var id = event.currentTarget.parentElement.getElementsByTagName('input')[0].value;
    document.getElementsByName('ReplyId')[0].value = id;
}