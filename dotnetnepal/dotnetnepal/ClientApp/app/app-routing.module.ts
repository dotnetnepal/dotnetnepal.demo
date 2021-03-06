﻿import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { LoginComponent } from "./components/login/login.component";
import { HomeComponent } from "./components/home/home.component";
import { SettingsComponent } from "./components/settings/settings.component";
import { AboutComponent } from "./components/about/about.component";
import { NotFoundComponent } from "./components/not-found/not-found.component";
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth-guard.service';
import { BlogsComponent } from "./components/blogs/blogs.component";
import { BlogReadComponent } from "./components/blog-read/blog-read.component";
import { NewBlogComponent } from "./components/blogs/new/new.component";
import { BlogEditComponent } from "./components/blogs/edit/edit.component";


@NgModule({
    imports: [
        RouterModule.forRoot([
            { path: "", component: HomeComponent, data: { title: "Home" } },
            { path: "login", component: LoginComponent, data: { title: "Login" } },
            { path: "settings", component: SettingsComponent, canActivate: [AuthGuard], data: { title: "Settings" } },
            { path: "about", component: AboutComponent, data: { title: "About Us" } },
            { path: "home", redirectTo: "/", pathMatch: "full" },
            {
                path: "blog",
                component: BlogsComponent,
                data: { title: "Blogs" },
                children: [
                    { path: 'new', component: NewBlogComponent, data: { title:"New Blog"} },
                    { path: 'edit', component: BlogEditComponent }
                ]
            },
            { path: "blog-read", component: BlogReadComponent, data: { title: "Blog Read" } },
            { path: "**", component: NotFoundComponent, data: { title: "Page Not Found" } },
        ])
    ],
    exports: [
        RouterModule
    ],
    providers: [
        AuthService, AuthGuard
    ]
})
export class AppRoutingModule { }