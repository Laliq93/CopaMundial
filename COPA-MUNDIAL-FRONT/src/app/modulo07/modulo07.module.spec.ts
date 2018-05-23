import { Modulo07Module } from './modulo07.module';

describe('Modulo07Module', () => {
  let modulo07Module: Modulo07Module;

  beforeEach(() => {
    modulo07Module = new Modulo07Module();
  });

  it('should create an instance', () => {
    expect(modulo07Module).toBeTruthy();
  });
});
