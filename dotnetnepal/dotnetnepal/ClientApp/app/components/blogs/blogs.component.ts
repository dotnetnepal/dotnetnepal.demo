import { Component, OnInit } from '@angular/core';
import { fadeInOut } from '../../services/animations';

import { Router } from '@angular/router';

import { Post } from '../../models/post.model';

import { BlogsService } from '../../services/blog.service';



@Component({
    selector: 'dotnetnepal-blogs',
    templateUrl: './blogs.component.html',
    styleUrls: ['./blogs.component.css'],
    animations: [fadeInOut]
})
export class BlogsComponent implements OnInit  {
    title = "Blogs";

    posts: Post[];

    constructor(
        private router: Router,
        private blogService: BlogsService) { }



    ngOnInit(): void {
        this.blogService.getPosts()
            .then(posts => this.posts = posts);
    }

    gotoDetail(post: Post): void {
        const link = ['/blog-read', post.id];
        this.router.navigate(link);
    }


}
