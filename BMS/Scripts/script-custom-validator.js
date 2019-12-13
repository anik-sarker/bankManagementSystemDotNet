$(documeent).ready(function() {
    $('#loginForm').validate({
        errorClass: 'help-block animation-slideDown',
        errorElement: 'div',
        errorPlacement: function(error, e) {
            e.parents('.form-group > div').append(error);
        },
        highlight: function(e) {
            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('help-block').remove();
        },
        success: function(e) {
            e.closest('.form-group').remodeClass('has-success has-error');
            e.closet('.help-block').remove();
        },
        rules: {
            'UserId': {
                required: true
            },
            'Password': {
                required: true,
                minlength: 6
            }
        },
        messages: {
            'UserId': 'Please enter valid user ID',
            'Password': {
                required: 'Please provide a password',
                minlength: 'Your password must be at least 6 characters long'
            }
        }

    });
});