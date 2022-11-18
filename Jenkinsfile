pipeline
{
	agent {label 'jenkins-slave-1'}
	environment
	{
		DOCKERHUB_CREDENTIALS = credentials('dockerhub')
	}
	stages
	{
		stage('gitclone')
		{
			steps
			{
				git 'https://github.com/Psp29/assignment1DotnetSQLite.git'
			}
		}
		stage('Build')
		{
			steps
			{
				sh 'docker build -t psp29/jenkinsassignment2:latest .'
			}
		}
		stage('Login')
		{
			steps
			{
				sh 'echo $DOCKERHUB_CREDENTIALS_PSW | docker login -u $DOCKERHUB_CREDENTIALS_USR --password-stdin'
			}
		}
		stage('Push')
		{
			steps
			{
				sh 'docker push psp29/jenkinsassignment2:latest'
			}
		}
		stage('Pull')
		{
			steps
			{
				sh 'docker pull psp29/jenkinsassignment2:latest'
			}
		}
		stage('Deploy')
		{
			steps
			{
				sh 'docker run --name jenkinsConDep -p 4000:80 psp29/jenkinsassignment2:latest'
			}
		}
	}
post
	{
		always
		{
			sh 'docker logout'
		}
	}
}
