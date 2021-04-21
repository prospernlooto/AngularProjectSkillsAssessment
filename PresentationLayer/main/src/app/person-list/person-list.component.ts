import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PersonDetailService } from '../shared/person-detail.service';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.css']
})
export class PersonListComponent implements OnInit {
  public term: string = '';

  constructor(public service: PersonDetailService) { }

  ngOnInit() {
    this.service.refreshList();
  }


  onSearch(form: NgForm) {
    this.service.searchList(this.term);
  }

  populateForm(selectedRecord) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(PMId) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.deletePaymentDetail(PMId);
    }
  }

  SearchBoxChanged() {
    if (this.term.length == 0) {
      this.service.refreshList();
    }
  }

}
