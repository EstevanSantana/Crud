import { UserRemoveComponent } from './user-remove/user-remove.component';
import { UserUpdateComponent } from './user-update/user-update.component';
import { UserCreateComponent } from './user-create/user-create.component';
import { UserListComponent } from './user-list/user-list.component';

import { RouterModule, Routes } from '@angular/router';
import { UserAppComponent } from './user.app.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
    {  
      path: '', component: UserAppComponent,
      children: [
        { path: 'lista-de-usuario', component: UserListComponent },
        { path: 'adicionar-usuario', component: UserCreateComponent },
        { path: 'editar/:id', component: UserUpdateComponent },
        { path: 'deletar/:id', component:  UserRemoveComponent},
      ]
    }
  ];
  
  @NgModule({
    imports: [ 
      RouterModule.forChild(routes),
    ],  
    exports: [RouterModule]
  })
  export class UserRoutingModule {}