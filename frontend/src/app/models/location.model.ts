export interface LocationModel {
  latitude?: number;
  longitude?: number;
  completeAddress?: string;

  isValid(): boolean;

  getLatitude(): number | undefined;

  getLongitude(): number | undefined;

  getCompleteAddress(): string | undefined;
}
