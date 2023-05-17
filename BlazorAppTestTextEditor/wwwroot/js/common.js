window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, 'Opperation Successful', { timeOut: 5000 })
    }
    if (type === "error") {
        toastr.error(message, 'Opperation Failed', { timeOut: 5000 })
    }
}
window.ShowSwal = (type, message) => {
    if (type === "Success") {
        Swal.fire({
            position: 'center',
            icon: 'success',
            title: message,
            showConfirmButton: false,
            timer: 5000
        })
    }
    if (type === "Error") {
        Swal.fire({
            position: 'center',
            icon: 'error',
            title: message,
            showConfirmButton: false,
            timer: 5000
        })
    }
}

function ShowDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}
function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}
