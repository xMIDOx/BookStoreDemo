import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgModel } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { BooksRoutingModule } from './books-routing-module';
import { BookForm } from './components/book-form/book-form';
import { BookList } from './components/book-list/book-list';


@NgModule({
  declarations: [],
  imports: [CommonModule, FormsModule, RouterModule, BooksRoutingModule, BookList, BookForm, NgModel, NgModule],
})
export class BooksModule {}
