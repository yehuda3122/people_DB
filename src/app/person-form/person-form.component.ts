import { Component } from '@angular/core';
import { PersonService } from '../person.service';
import { Person } from '../Person';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.css']
})
export class PersonFormComponent {
  person: Person = {
    numberId: 0,
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: ''
  };
  errorMessage: string = '';
  successMessage: string = '';

  constructor(private personService: PersonService) { }

  onSubmit() {
    this.personService.addPerson(this.person).subscribe({
      next: () => {
        this.successMessage = 'Person added successfully!';
        this.errorMessage = '';
      },
      error: (err) => this.errorMessage = err
    }
    );
  }
  resetForm() {
    this.person = {
      numberId: 0,
      firstName: '',
      lastName: '',
      email: '',
      phoneNumber: ''
    };
  }
}
