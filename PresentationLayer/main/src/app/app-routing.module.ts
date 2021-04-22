import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutMeViewComponent } from './pages/about-me-view/about-me-view.component';
import { AccountsListComponent } from './pages/accounts-list/accounts-list.component';
import { ContactMeViewComponent } from './pages/contact-me-view/contact-me-view.component';
import { TransactionsListComponent } from './pages/transactions-list/transactions-list.component';
import { WelcomeViewComponent } from './pages/welcome-view/welcome-view.component';
import { PersonListComponent } from './person-list/person-list.component';


const routes: Routes = [
  { path: 'personslist', component: PersonListComponent },
  { path: 'accounts-list', component: AccountsListComponent },
  { path: 'transaction-list', component: TransactionsListComponent },
  { path: 'welcome', component: WelcomeViewComponent },
  { path: 'about-me', component: AboutMeViewComponent },
  { path: 'contact-me', component: ContactMeViewComponent },
  { path: '', redirectTo: '/welcome', pathMatch: 'full' }, // redirect to 
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
