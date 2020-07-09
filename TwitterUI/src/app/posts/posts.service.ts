import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { BehaviorSubject } from 'rxjs';
import { Post } from './post.model';

@Injectable({
  providedIn: 'root'
})
export class PostsService {

  postsSubject = new BehaviorSubject<Post[]>(null);

  hostEndPoint = "https://localhost:44306/api/post";

  constructor(private http: HttpClient) { }

  fetchPosts() {
    return this.http.get<Post[]>(this.hostEndPoint);
  }

  fetchPostsByHashtag(hashtag: string) {
    return this.http.get<Post[]>(this.hostEndPoint + '?hashtag=' + hashtag);
  }

  sharePost(new_post: Post) {
    return this.http.post<any>(this.hostEndPoint, new_post);
  }
}