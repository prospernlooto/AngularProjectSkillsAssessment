import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountsDetailService } from '../../shared/accounts-detail.service';

@Component({
  selector: 'app-accounts-list',
  templateUrl: './accounts-list.component.html',
  styleUrls: ['./accounts-list.component.css']
})
export class AccountsListComponent implements OnInit {
  
  constructor(private route: ActivatedRoute,
    private router: Router, public service: AccountsDetailService) {
   
  }

  ngOnInit() {
    const person_code: string = this.route.snapshot.queryParamMap.get('person_code');
    this.service.formData.person_code = parseInt(person_code);
    this.service.refreshList(this.service.formData.person_code);

    //alert(this.person_code);

  }

  populateForm(selectedRecord) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(PMId) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.deletePaymentDetail(PMId);
    }
  }

}
