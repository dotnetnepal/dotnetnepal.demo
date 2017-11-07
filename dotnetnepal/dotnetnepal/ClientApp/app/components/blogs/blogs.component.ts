import { Component } from '@angular/core';
import { fadeInOut } from '../../services/animations';

@Component({
    selector: 'blogs',
    templateUrl: './blogs.component.html',
    styleUrls: ['./blogs.component.css'],
    animations: [fadeInOut]
})
export class BlogsComponent {
}
