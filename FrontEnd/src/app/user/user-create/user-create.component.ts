import { ToastrService } from 'ngx-toastr';
import { User } from './../models/user';
import { UserService } from './../services/user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html'
})
export class UserCreateComponent implements OnInit {
  
  public errors: any[];
  public form: FormGroup;
  public formResult: string = '';
  public user: User;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private router: Router,
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.maxLength(50), Validators.min(2)]],
      lastName: ['', [Validators.required, Validators.maxLength(50), Validators.min(2)]],
      birthday: ['', [Validators.required]],
      schooling: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  public add() {
    if (this.form.dirty && this.form.valid) {
      this.user = Object.assign({}, this.user, this.form.value);
      this.formResult = JSON.stringify(this.form.value);

      this.userService.add(this.user)
      .subscribe({
        next: (res) => {
          this.sucesso(res)
        },
        error: (e) => {
          let errorMessage = [];

          for (let i = 0; i < e.error.error.length; i++) {
            errorMessage.push(e.error.error[i]);
          }
          this.errors = errorMessage
        } 
      }); 
    }else {
      this.formResult = "Opa! erro";
    }
  }

  public sucesso(response: any){
    this.form.reset();

    let toast = this.toastr.success('Cadastro com sucesso!', 'Sucesso!');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/usuarios/lista-de-usuario']);
      });
    }
  }

}
