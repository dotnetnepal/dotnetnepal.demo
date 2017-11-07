import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';

import { catchError, map, tap } from 'rxjs/Operators';


import { Post } from '../models/post.model';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class BlogsService {
    private blogUrl = '';

    constructor(
        private http: HttpClient,
    ) { }

    getPosts(): Observable<Post[]> {
        return this.http.get<Post[]>(this.blogUrl)
            .pipe(
            tap(posts = > this.log('fetched posts')),
            catchError(this.handleError('getPosts',[])
            )
    }

}
