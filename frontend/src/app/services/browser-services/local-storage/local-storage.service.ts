import {Injectable} from '@angular/core';
import {LocationModel} from "../../../models/location.model";

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  set(key: string, value: string): void {
    localStorage.setItem(key, value);
  }

  get<T>(key: string): T | undefined {
    let stringValue = localStorage.getItem(key);
    if (!stringValue) return undefined;

    let jsonObject = JSON.parse(stringValue);
    return <T>jsonObject;
  }

  remove(key: string): void {
    localStorage.removeItem(key);
  }
}
