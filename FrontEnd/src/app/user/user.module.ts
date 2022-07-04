import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';

import { UserAppComponent } from './user.app.component';
import { UserListComponent } from './user-list/user-list.component';
import { UserCreateComponent } from './user-create/user-create.component';
import { UserUpdateComponent } from './user-update/user-update.component';
import { UserRoutingModule } from './user.route';
import { UserService } from './services/user.service';
import { UserRemoveComponent } from './user-remove/user-remove.component';

@NgModule({
    declarations: [
        UserAppComponent,
        UserCreateComponent,
        UserUpdateComponent,
        UserListComponent,
        UserRemoveComponent
    ],
    imports: [ 
        CommonModule,
        UserRoutingModule,
        RouterModule,
        ReactiveFormsModule,
        FormsModule,   
        HttpClientModule,
        //ToastrModule,
    ],
    providers: [UserService],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]

})
export class UserModule {}