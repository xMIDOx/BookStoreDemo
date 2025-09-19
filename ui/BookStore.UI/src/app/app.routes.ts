import { Routes } from '@angular/router';

import { BookForm } from './features/books/components/book-form/book-form';
import { BookList } from './features/books/components/book-list/book-list';

export const routes: Routes = [
  {
    path: 'books',
    children: [
      { path: '', component: BookList },
      { path: 'add', component: BookForm },
      { path: 'edit/:id', component: BookForm }
    ]
  },
  { path: '', redirectTo: 'books', pathMatch: 'full' }
];
