import { Component } from '@angular/core';
import { fadeInOut } from '../../services/animations';

@Component({
    selector: 'dotnetnepal-blog-read',
    templateUrl: './blog-read.component.html',
    styleUrls: ['./blog-read.component.css'],
    animations: [fadeInOut]
})
export class BlogReadComponent {
    title ="Blog Read"
}
