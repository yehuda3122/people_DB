import { Injectable } from '@angular/core';
import { HttpBackend, HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { Person } from './Person';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  private apiUrl = 'http://localhost:5278/api/people';


  constructor(private http: HttpClient, private handler: HttpBackend) {
    this.http = new HttpClient(handler);
  }

  getPeople(): Observable<Person[]> {
    return this.http.get<Person[]>(this.apiUrl);
  }


  addPerson(person: Person): Observable<Person> {
    return this.http.post<Person>(this.apiUrl, person)
      .pipe(
        catchError(this.handleError)
      );
  }


  deletePerson(numberId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${numberId}`);
  }





  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {

      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
  
    return throwError(error.error.message || 'Something bad happened; please try again later.');
  }
}
