import { Component, OnInit, OnDestroy } from '@angular/core';
import { MatDialogConfig, MatDialog } from '@angular/material';

import { PostsService } from '../posts.service';
import { Post } from '../post.model';
import { NewPostComponent } from '../new-post/new-post.component';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-list',
  templateUrl: './posts-list.component.html',
  styleUrls: ['./posts-list.component.scss']
})
export class PostsListComponent implements OnInit, OnDestroy {

  posts: Post[];
  errorMessage: string;
  isErrorVisible: boolean;
  isInfoVisible: boolean;
  infoMessage: string;
  hashtag: string;

  posts_subscription: Subscription;

  constructor(private postService: PostsService, private dialog: MatDialog) { }

  ngOnDestroy() {
    this.posts_subscription.unsubscribe();
  }

  ngOnInit() {
    this.posts_subscription = this.postService.postsSubject.subscribe((posts: Post[]) => {
      this.posts = posts;
    });
    this.setPosts();
  }

  setPosts() {
    this.postService.fetchPosts().subscribe(
      (result: Post[]) => {
        this.postService.postsSubject.next(result);
        this.isErrorVisible = false;
        if (result.length < 1) {
          this.isInfoVisible = true;
          this.infoMessage = "No Posts to Show !";
        }
        else {
          this.isInfoVisible = false;
        }
      },
      error => {
        this.errorMessage = error.error.message;
        this.isErrorVisible = true;
        this.isInfoVisible = false;
      }
    );
  }

  searchByHashtag() {
    if (this.hashtag) {
      //remove '#' char.
      const hashtag = this.hashtag.replace(/#/, '');

      this.postService.fetchPostsByHashtag(hashtag).subscribe(
        (result: Post[]) => {
          this.postService.postsSubject.next(result);
          if (result.length < 1) {
            this.isInfoVisible = true;
            this.infoMessage = "No Posts to Show !";
          }
          else {
            this.isInfoVisible = false;
          }

          this.isErrorVisible = false;
        },
        error => {
          this.errorMessage = error.error.message;
          this.isErrorVisible = true;
          this.isInfoVisible = false;
        }
      );
    }
    else {
      this.setPosts();
    }
  }

  openDialog() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.width = "640px";
    dialogConfig.height = "260px";
    dialogConfig.panelClass = "custom-dialog-container";
    this.dialog.open(NewPostComponent, dialogConfig);
  }
}
