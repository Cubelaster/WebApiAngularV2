import { ToastOptions } from 'ng2-toastr';

export class CustomToastrOptions extends ToastOptions {
    toastLife = 4000;
    dismiss = 'auto';
    newestOnTop = true;
    showCloseButton = true;
    animate = 'fade'; // you can pass any options to override defaults
}