import React from 'react';

export function createRoutes(modules) {
  const routesFromModules = modules.map(module => module.getRoutes());
  return (
    <React.Fragment>
      {routesFromModules}
    </React.Fragment>
  );
}