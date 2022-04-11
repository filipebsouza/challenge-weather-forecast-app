import {Observable} from 'rxjs';

export interface GenericApiContract {
  get<ReturnType>(resource: string, ...args: any): Observable<ReturnType>;
}
