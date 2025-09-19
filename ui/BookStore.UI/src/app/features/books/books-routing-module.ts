import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BookForm } from './components/book-form/book-form';
import { BookList } from './components/book-list/book-list';

const routes: Routes = [
  { path: '', component: BookList },
  { path: 'add', component: BookForm },
  { path: 'edit/:id', component: BookForm }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BooksRoutingModule { }
