import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Author {
  id: number;
  firstName: string;
  lastName: string;
  bio: string;
}


@Injectable({ providedIn: 'root' })
export class AuthorService {
  private baseUrl = 'https://localhost:44300/api/authors'; // adjust port if needed

  constructor(private http: HttpClient) {}

  getAuthors(): Observable<Author[]> {
    return this.http.get<Author[]>(this.baseUrl);
  }
}
