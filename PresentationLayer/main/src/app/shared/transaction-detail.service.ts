import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TransactionDetail } from './transaction-detail.model';

@Injectable({
  providedIn: 'root'
})
export class TransactionDetailService {

  formData: TransactionDetail = new TransactionDetail();
  readonly baseURL = 'https://localhost:44341/api/Transactions/';
  list: TransactionDetail[];

  constructor(private http: HttpClient) { }

  refreshList(account_code: number) {
    this.http.get(this.baseURL + `GetTransactionsByAccountCode/${account_code}`)
      .toPromise()
      .then(res => this.list = res as TransactionDetail[]);
  }

  postPaymentDetail() {
    return this.http.post(this.baseURL + 'AddTransactions', this.formData);
  }
  putPaymentDetail() {
    return this.http.post(this.baseURL + 'UpdateTransaction', this.formData);
  }
}
