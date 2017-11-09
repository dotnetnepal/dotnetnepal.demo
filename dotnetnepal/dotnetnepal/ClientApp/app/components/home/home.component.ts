

import { Component } from '@angular/core';
import { fadeInOut } from '../../services/animations';
import { ConfigurationService } from '../../services/configuration.service';


@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css'],
    animations: [fadeInOut]
})
export class HomeComponent {
    constructor(public configurations: ConfigurationService) {
    }

    text: any = {
        Year: 'Year',
        Month: 'Month',
        Weeks: "Weeks",
        Days: "Days",
        Hours: "Hours",
        Minutes: "Minutes",
        Seconds: "Seconds",
        MilliSeconds: "MilliSeconds"
    };
}
