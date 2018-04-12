function openEditPost(element) {
    var id = element.id;
    $('#msg-' + id).css({ 'display': 'none' });
    $('#view-edit-'+id).css({'display':'block'});
}

function closeEditPost(element) {
    var id = element.id;
    $('#msg-' + id).css({ 'display': 'block' });
    $('#view-edit-' + id).css({ 'display': 'none' });
}

function openEditComment(element) {
    var id = element.id;

    $('#comment-' + id).css({ 'display': 'none' });
    $('#edit-comment-' + id).css({ 'display': 'block' });
}

function closeEditComment(element) {
    var id = element.id;

    $('#comment-' + id).css({ 'display': 'block' });
    $('#edit-comment-' + id).css({ 'display': 'none' });
}

function openEditProfile() {
    $('#details-profile').css({ 'display': 'none' });
    $('#edit-profile').css({ 'display': 'block' });
}