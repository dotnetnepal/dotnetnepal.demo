import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';



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

  

}
