import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';

import { Post } from '../models/post.model';
import 'rxjs/add/operator/toPromise';

const httpOptions = {
    headers: new Headers({ 'Content-Type': 'application/json' })
};

@Injectable()
export class BlogsService {
    private blogUrl = 'http://dotnetnepal.azurewebsites.net/api/blogs';

    constructor(
        private http: Http
    ) { }


    getPosts(): Promise<Array<Post>> {
        return this.http
            .get(this.blogUrl)
            .toPromise()
            .then((response) => {
                return response.json().data as Post[];
            })
            .catch(this.handleError);
    }

    getPost(id: number): Promise<Post> {
        return this.getPosts()
            .then(post => post.find(post => post.id === id));
    }

    save(post: Post): Promise<Post> {
        if (post.id) {
            return this.put(post);
        }
        return this.post(post);
    }

    delete(post: Post): Promise<Response> {
        const headers = new Headers();
        headers.append('Content-Type', 'application/json');

        const url = `${this.blogUrl}/${post.id}`;

        return this.http
            .delete(url, { headers: headers })
            .toPromise()
            .catch(this.handleError);
    }


    private post(post: Post): Promise<Post> {
        const headers = new Headers({
            'Content-Type': 'application/json'
        });

        return this.http
            .post(this.blogUrl, JSON.stringify(Post), { headers: headers })
            .toPromise()
            .then(res => res.json().data)
            .catch(this.handleError);
    }

    // Update existing Hero
    private put(post: Post): Promise<Post> {
        const headers = new Headers();
        headers.append('Content-Type', 'application/json');

        const url = `${this.blogUrl}/${post.id}`;

        return this.http
            .put(url, JSON.stringify(post), { headers: headers })
            .toPromise()
            .then(() => post)
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }

}
