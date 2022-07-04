import { User } from './../models/user';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { catchError, throwError } from 'rxjs';

const baseUrl = 'https://localhost:5001/api/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  public add(user: User): Observable<User> {
    return this.httpClient.post<User>(`${baseUrl}/register-new-user`, user)
    
  }

  public update(user: User): Observable<User> {
    return this.httpClient.put<User>(`${baseUrl}/update-user`, user);
  }

  public remove(id: string): Observable<User> {
    return this.httpClient.delete<User>(`${baseUrl}/delete-user/${id}`);
  }

  public getAll(): Observable<User[]> {
    return this.httpClient.get<User[]>(baseUrl);
  }

  public getById(id: string): Observable<User> {
    return this.httpClient.get<User>(`${baseUrl}/${id}`);
  }

  errorHandler(error:any) {
    let errorMessage = '';

    for (let i = 0; i < error.error.length; i++) {
      errorMessage = error.error[i]
  
    }
    return throwError(errorMessage);
  }
}
