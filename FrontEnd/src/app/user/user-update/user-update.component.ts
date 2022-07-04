import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from '../models/user';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user-update',
  templateUrl: './user-update.component.html'
})
export class UserUpdateComponent implements OnInit {

  public errors: any[];
  public userId: string;
  public user: User;
  public form: FormGroup;
  public formResult: string = '';
  
  constructor(
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private userService: UserService,
    private router: Router,
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.userId = this.route.snapshot.params['id'];
    
    this.userService.getById(this.userId)
      .subscribe(
        user => {
          this.user = user;
          this.form.patchValue(user);
        }
      )
      
    this.form = this.formBuilder.group({
      fistName: ['', [Validators.required, Validators.maxLength(50), Validators.min(2)]],
      lastName: ['', [Validators.required, Validators.maxLength(50), Validators.min(2)]],
      birthday: ['', [Validators.required]],
      schooling: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  
  public update() {
    if (this.form.dirty && this.form.valid) {
      this.user = Object.assign({}, this.user, this.form.value);
      this.formResult = JSON.stringify(this.form.value);

      this.userService.update(this.user)
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
