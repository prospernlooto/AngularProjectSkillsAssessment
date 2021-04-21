import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountsListComponent } from './pages/accounts-list/accounts-list.component';
import { TransactionsListComponent } from './pages/transactions-list/transactions-list.component';
import { PersonListComponent } from './person-list/person-list.component';


const routes: Routes = [
  { path: 'personslist', component: PersonListComponent },
  { path: 'accounts-list', component: AccountsListComponent },
  { path: 'transaction-list', component: TransactionsListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
