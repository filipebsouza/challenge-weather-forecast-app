export interface LocationModel {
  latitude?: number;
  longitude?: number;
  completeAddress?: string;

  hasSuccess(): boolean;

  getLatitude(): number | undefined;

  getLongitude(): number | undefined;

  getCompleteAddress(): string | undefined;
}
