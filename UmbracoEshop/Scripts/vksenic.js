$(document).ready(function () {
    // Contact
    vksenicContactFormApi();
});

/* contact */
function vksenicContactFormApi() {
    if ($('.api-password-group').length > 0) {
        $.ajax('/Umbraco/UmbracoEshop/UmbracoEshopApi/ContactFormApiKey',
            {
                type: 'POST',
                success: function (data) {
                    $('.api-password-group #Password').val(data.MainKey);
                    $('.api-password-group #ConfirmPassword').val(data.SubKey);
                }
            });
    }
}