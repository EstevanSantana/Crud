import { UserService } from './../services/user.service';
import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html'
})
export class UserListComponent implements OnInit {

  public users: User[];

  constructor(
    private userService: UserService,
  ) { }

  ngOnInit(): void {
    this.userService.getAll().subscribe(
      response => { this.users = response;
        console.log(response)
      },
      error => { console.log(error) }
    );
      
  }

}
