import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { ArticleDto } from '../model/ArticleDto';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['./fetch-data.component.css']
})
export class ExportPriceOfArticle {
  public specificDate: Date;
  public articles: ArticleDto[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  public onGetData(): void {
    if (this.specificDate) {
      const headers = new HttpHeaders().append('header', 'value');
      const params = new HttpParams().append('date', this.specificDate.toLocaleString());
      this.http.get<ArticleDto[]>(this.baseUrl + 'exportdata', { headers, params }).subscribe(result => {
        this.articles = result;
      }, error => console.error(error));
    } else {
      alert("You should enter a date before export data.");
    }
  }
}
