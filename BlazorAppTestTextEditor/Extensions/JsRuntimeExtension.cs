using Microsoft.JSInterop;

namespace BlazorAppTestTextEditor.Extensions
{
    public static class JsRuntimeExtension
    {
        public static async ValueTask<bool> TestConfirm(this IJSRuntime jSRuntime, string ConfirMessage)
        {
            return await jSRuntime.InvokeAsync<bool>("confirm", ConfirMessage);
        }
        public static async ValueTask ToastrSuccess(this IJSRuntime jSRuntime, string Message)
        {
            await jSRuntime.InvokeVoidAsync("ShowToastr", "success", Message);
        }
        public static async ValueTask ToastrError(this IJSRuntime jSRuntime, string Message)
        {
            await jSRuntime.InvokeVoidAsync("ShowToastr", "error", Message);
        }
        public static async ValueTask SweetAlertSuccess(this IJSRuntime jSRuntime, string Message)
        {
            await jSRuntime.InvokeVoidAsync("ShowSwal", "Success", Message);
        }
        public static async ValueTask SweetAlertError(this IJSRuntime jSRuntime, string Message)
        {
            await jSRuntime.InvokeVoidAsync("ShowSwal", "Error", Message);
        }
    }
}
