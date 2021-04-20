import { Component, OnInit } from '@angular/core';
import { PersonDetailService } from '../shared/person-detail.service';

@Component({
  selector: 'app-person-details',
  templateUrl: './person-details.component.html',
  styles: [
  ]
})
export class PersonDetailsComponent implements OnInit {

  constructor(public service: PersonDetailService) { }

  ngOnInit() {

    this.service.refreshList();
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
