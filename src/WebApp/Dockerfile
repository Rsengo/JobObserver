# You should always specify a full version here to ensure all of your developers
# are running the same version of Node.
FROM node:11.15.0

# Создать директорию app
WORKDIR /app

# Установить зависимости приложения
# Используется символ подстановки для копирования как package.json, так и package-lock.json,
# работает с npm@5+
COPY src/WebApp/package*.json ./

RUN npm install
# Используется при сборке кода в продакшене
# RUN npm install --only=production

# Скопировать исходники приложения
COPY ./src/WebApp /app

# Expose the app port
EXPOSE 8000

# Запуск проекта
CMD [ "npm", "run", "browser:dev" ]