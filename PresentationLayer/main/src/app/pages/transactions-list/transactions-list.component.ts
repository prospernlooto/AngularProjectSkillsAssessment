import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TransactionDetailService } from '../../shared/transaction-detail.service';

@Component({
  selector: 'app-transactions-list',
  templateUrl: './transactions-list.component.html',
  styleUrls: ['./transactions-list.component.css']
})
export class TransactionsListComponent implements OnInit {

 

  constructor(private route: ActivatedRoute,
    private router: Router, public service: TransactionDetailService) { }

  ngOnInit() {
    const account_code: string = this.route.snapshot.queryParamMap.get('account_code');
    this.service.formData.account_code = parseInt(account_code);
    this.service.refreshList(this.service.formData.account_code);
  }

  populateForm(selectedRecord) {

    let date = new Date(selectedRecord.transaction_date);

    var day = ("0" + date.getDate()).slice(-2);
    var month = ("0" + (date.getMonth() + 1)).slice(-2);

    selectedRecord.transaction_date = date.getFullYear() + "-" + (month) + "-" + (day);

    this.service.formData = Object.assign({}, selectedRecord);
  }

}
