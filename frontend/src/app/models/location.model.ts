export interface LocationModel {
  latitude?: number;
  longitude?: number;
  hasSuccess(): boolean;

  getLatitude(): number | undefined;
  getLongitude(): number | undefined;
}
