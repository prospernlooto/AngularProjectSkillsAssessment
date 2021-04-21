import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { PersonDetail } from './person-detail.model';

@Injectable({
  providedIn: 'root'
})
export class PersonDetailService {

  formData: PersonDetail = new PersonDetail();
  readonly baseURL = 'https://localhost:44341/api/Persons/';
  list: PersonDetail[];

  constructor(private http: HttpClient) { }

  refreshList() {
    this.http.get(this.baseURL + 'GetAllPersons')
      .toPromise()
      .then(res => this.list = res as PersonDetail[]);
  }

  postPaymentDetail() {
    return this.http.post(this.baseURL + 'AddPersons', this.formData);
  }


  putPaymentDetail() {
    return this.http.post(this.baseURL + 'UpdatePersons', this.formData);
  }

  deletePaymentDetail(code: number) {
    return this.http.get(this.baseURL + `DeletePersons/${code}`)
      .toPromise()
      .then(res => this.list = res as PersonDetail[])
      .catch(err => alert(err.error.Message));
  }
  searchList(term: string) {
    this.http.get(this.baseURL + `Search/${term}`)
      .toPromise()
      .then(res => this.list = res as PersonDetail[]);
  }
}
