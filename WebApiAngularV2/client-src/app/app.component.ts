import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Hero } from './Models/ViewModelExports';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
}) 

export class AppComponent implements OnInit {
    constructor(private _httpService: Http) { }

    apiValues: string[] = [];
    title = "Tour of Heroes";
    MyHero = new Hero("Thor");

    ngOnInit() {
        this._httpService.get('/api/values').subscribe(values => {
            this.apiValues = values.json().join().replace(',', ' ') as string[];
        });
    }
}