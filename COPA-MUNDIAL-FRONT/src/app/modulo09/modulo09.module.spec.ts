import { Modulo09Module } from './modulo09.module';

describe('Modulo09Module', () => {
  let modulo09Module: Modulo09Module;

  beforeEach(() => {
    modulo09Module = new Modulo09Module();
  });

  it('should create an instance', () => {
    expect(modulo09Module).toBeTruthy();
  });
});
