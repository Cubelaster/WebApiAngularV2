import { Component, OnInit } from '@angular/core';

import { HomeDetails } from '../../../Models/index';
import { DashboardService, AlertService } from '../../../Services/services';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

    homeDetails: HomeDetails;

    constructor(private dashboardService: DashboardService, private alertService: AlertService) { }

    ngOnInit() {

        this.dashboardService.getHomeDetails()
            .subscribe((homeDetails: HomeDetails) => {
                this.homeDetails = homeDetails;
            },
            error => {
                this.alertService.error(error, true);
            });

    }
}
