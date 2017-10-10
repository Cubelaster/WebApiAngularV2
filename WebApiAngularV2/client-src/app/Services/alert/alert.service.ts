import { Injectable } from '@angular/core';
import { Router, NavigationStart } from '@angular/router';
import { Observable } from 'rxjs';
import { Subject } from 'rxjs/Subject';
import { Alert, AlertType } from '../../Utils/Models/AlertModel';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Injectable()
export class AlertService {
    private subject = new Subject<any>();
    private keepAfterNavigationChange = false;

    constructor(private router: Router, private toastr: ToastsManager) {
        // clear alert message on route change
        router.events.subscribe(event => {
            if (event instanceof NavigationStart) {
                if (this.keepAfterNavigationChange) {
                    // only keep for a single location change
                    this.keepAfterNavigationChange = false;
                } else {
                    // clear alert
                    this.clear();
                }
            }
        });
    }

    clear() {
        // clear alerts
        this.subject.next();
    }

    getAlert(): Observable<any> {
        return this.subject.asObservable();
    }

    success(message: string, keepAfterRouteChange = false) {
        this.toastr.success(message, AlertType.Success);
    }

    error(message: string, keepAfterRouteChange = false) {
        this.toastr.error(message, AlertType.Error);
    }

    info(message: string, keepAfterRouteChange = false) {
        this.toastr.info(message, AlertType.Info);
    }

    warn(message: string, keepAfterRouteChange = false) {
        this.toastr.warning(message, AlertType.Warning);
    }

    getMessage(): Observable<any> {
        return this.subject.asObservable();
    }
}