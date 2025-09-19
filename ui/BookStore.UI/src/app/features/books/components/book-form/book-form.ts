import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';

import { Author, AuthorService } from '../../../../core/services/author';
import { Book, BookService, CreateBook } from '../../../../core/services/book';

@Component({
  selector: 'app-book-form',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './book-form.html',
  styleUrls: ['./book-form.css'],
})
export class BookForm implements OnInit {
  book: Partial<Book> = {};
  isEdit = false;
  authors: Author[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private bookService: BookService,
    private authorService: AuthorService
  ) {}

  ngOnInit(): void {
    this.authorService.getAuthors().subscribe((data) => (this.authors = data));
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEdit = true;
      this.bookService.getBook(+id).subscribe((data) => {
        console.log(data);
        this.book = data;
      });
    }
  }

  saveBook(): void {
    if (this.isEdit && this.book.id) {
      this.bookService.updateBook(this.book.id, this.book as Book).subscribe(() => {
        this.router.navigate(['/books']);
      });
    } else {
      this.bookService.addBook(this.book as CreateBook).subscribe(() => {
        this.router.navigate(['/books']);
      });
    }
  }
}
